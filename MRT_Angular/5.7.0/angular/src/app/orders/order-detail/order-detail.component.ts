import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  OrderDto, OrderServiceProxy, OrderDtoPagedResultDto, MenuItemServiceProxy, MenuServiceProxy, MenuDto, MenuDtoPagedResultDto, OrderStatusDtoPagedResultDto, OrderStatusServiceProxy, OrderStatusDto, OrderDtoListResultDto, OrderLineDto, OrderLineServiceProxy
} from '../../../shared/service-proxies/service-proxies';
import { EditOrderDialogComponent } from '../edit-order/edit-order-dialog.component';
import { CreateOrderDialogComponent } from '../create-order/create-order-dialog.component';




@Component({
  templateUrl: 'order-detail.component.html'
})
export class OrderDetailComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  Iid: number;
  menus: MenuDto[]=[];
  linkedMenus:MenuDto[]=[];
  restautrant: OrderDto = new OrderDto();
  orderdIdFk:number;
  orderId:number;
  public searchText:string;
  loading:boolean = true;
  advancedFiltersVisible = false;
  statusses: OrderStatusDto[]=[];
  resStatus:OrderStatusDto = new OrderStatusDto();
  orderStatusIdFk:number;
  orders:OrderDto[]=[];
  linkedOrderLines: OrderLineDto[]=[];



  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public _orderService: OrderServiceProxy,
    private activeRoute: ActivatedRoute,
    private _router: Router,
    private _modalService: BsModalService,
    private _statusService: OrderStatusServiceProxy,
    private _orderLineService: OrderLineServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    localStorage.setItem('orderId',id);
    this.orderId =+ localStorage.getItem('orderId');
    console.log(this.orderId);
    this._orderService.getOrderById(this.Iid).subscribe((result: OrderDtoListResultDto) => {
      this.orders = result.items;
      this.orderStatusIdFk = this.orders[0].orderStatusIdFk;
      this.orderId = this.orders[0].id;
      this.linkedOrderLines = this.orders[0].orderLine;
      this.loading = false;
      console.log(this.linkedOrderLines);
    });

  }

  save(): void {
    this.saving = true;

    this._orderService
      .update(this.order)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }

  editOrder(): void {
    this.showCreateOrEditOrderDialog();
  }

  showCreateOrEditOrderDialog(): void {
    let createOrEditOrderDialog: BsModalRef;
      createOrEditOrderDialog = this._modalService.show(
        EditOrderDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: this.Iid,
          },
        }
      );


    createOrEditOrderDialog.content.onSave.subscribe(() => {
      let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._orderService.getOrderById(this.Iid).subscribe((result: OrderDtoListResultDto) => {
      this.orders = result.items;
      this.orderStatusIdFk = this.orders[0].orderStatusIdFk;
      this.orderId = this.orders[0].id;
      this.linkedOrderLines = this.orders[0].orderLine;
      this.loading = false;
    });
    });
  }

  delete(line: OrderLineDto): void {
    abp.message.confirm(
      this.l('MenuDeleteWarningMessage', line.menuItemIdFkNavigation.menuItemName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderLineService
            .delete(line.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                let id: string = this.activeRoute.snapshot.params['id'];
                this.Iid =+ id;
                this._orderService.getOrderById(this.Iid).subscribe((result: OrderDtoListResultDto) => {
                  this.orders = result.items;
                  this.orderStatusIdFk = this.orders[0].orderStatusIdFk;
                  this.orderId = this.orders[0].id;
                  this.linkedOrderLines = this.orders[0].orderLine;
                  this.loading = false;
                });
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  addToOrder(){
      const detailsUrl: string = `/app/orderLine`;
      this._router.navigate([detailsUrl]);
  }

  }

