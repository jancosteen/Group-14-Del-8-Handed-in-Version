import {
  Component,
  ChangeDetectionStrategy,
  Injector,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'sidebar-user-panel',
  templateUrl: './sidebar-user-panel.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SidebarUserPanelComponent extends AppComponentBase
  implements OnInit {
  shownLoginName = '';

  constructor(injector: Injector,
    public _router:Router) {
    super(injector);
  }

  ngOnInit() {
    this.shownLoginName = this.appSession.getShownLoginName();
  }

  goToViewUser(){
    const detailsUrl: string = `/app/viewUser`;
    this._router.navigate([detailsUrl]);
  }
}
