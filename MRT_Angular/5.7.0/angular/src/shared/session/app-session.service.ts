import { AbpMultiTenancyService } from 'abp-ng2-module';
import { Injectable } from '@angular/core';
import {
    ApplicationInfoDto,
    GetCurrentLoginInformationsOutput,
    MenuItemDto,
    SessionServiceProxy,
    TenantLoginInfoDto,
    UserLoginInfoDto
} from '@shared/service-proxies/service-proxies';
import { BehaviorSubject } from 'rxjs';


@Injectable()
export class AppSessionService {

    private cart = [];
    private cartCount:number = 0;
    private cartItemCount = new BehaviorSubject(0);
    private _user: UserLoginInfoDto;
    private _tenant: TenantLoginInfoDto;
    private _application: ApplicationInfoDto;

    constructor(
        private _sessionService: SessionServiceProxy,
        private _abpMultiTenancyService: AbpMultiTenancyService) {
    }

    get application(): ApplicationInfoDto {
        return this._application;
    }

    get user(): UserLoginInfoDto {
        return this._user;
    }

    get userId(): number {
        return this.user ? this.user.id : null;
    }

    get tenant(): TenantLoginInfoDto {
        return this._tenant;
    }

    get tenantId(): number {
        return this.tenant ? this.tenant.id : null;
    }


    getShownLoginName(): string {
        const userName = this._user.userName;
        if (!this._abpMultiTenancyService.isEnabled) {
            return userName;
        }

        return (this._tenant ? this._tenant.tenancyName : '.') + '\\' + userName;
    }

    init(): Promise<boolean> {
        return new Promise<boolean>((resolve, reject) => {
            this._sessionService.getCurrentLoginInformations().toPromise().then((result: GetCurrentLoginInformationsOutput) => {
                this._application = result.application;
                this._user = result.user;
                this._tenant = result.tenant;

                resolve(true);
            }, (err) => {
                reject(err);
            });
        });
    }

    changeTenantIfNeeded(tenantId?: number): boolean {
        if (this.isCurrentTenant(tenantId)) {
            return false;
        }

        abp.multiTenancy.setTenantIdCookie(tenantId);
        location.reload();
        return true;
    }

    private isCurrentTenant(tenantId?: number) {
        if (!tenantId && this.tenant) {
            return false;
        } else if (tenantId && (!this.tenant || this.tenant.id !== tenantId)) {
            return false;
        }

        return true;
    }

    getCart() {
        return this.cart;
      }

      getCartItemCount() {
        return this.cartCount;
      }

      addProduct(item) {
        let added=false;
        for(let x of this.cart){
            if(x.item.id === item.id){
                x.qty +=1;
                added=true;
                break;
            }
        }
        if(!added){
        this.cart.push({item, qty:1});
        }

        this.cartCount += 1;
        console.log(this.cart);
      }

      decreaseProduct(product) {
        for (let x=0;x<this.cart.length;x++) {
          if (this.cart[x].item.id === product.item.id) {
            this.cart[x].qty -= 1;
            if (this.cart[x].qty == 0) {
              this.cart.splice(x, 1);
            }
          }
        }
        this.cartCount = this.cartCount-1;
      }

      clearCart(){
          this.cart = [];
      }

      removeProduct(product) {
        for (let [index, p] of this.cart) {
          if (p.id === product.id) {
            this.cartCount = this.cartCount - p.qty;
            this.cart.splice(index, 1);
          }
        }
      }
}

