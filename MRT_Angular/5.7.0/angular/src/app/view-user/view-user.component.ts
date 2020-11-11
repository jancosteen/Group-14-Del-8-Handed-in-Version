import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { UserDto, UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.css']
})
export class ViewUserComponent extends AppComponentBase implements OnInit {

  user:UserDto = new UserDto();
  userId;
  fullName:string;
  editCheck:boolean;


  constructor(
    private _sessionService: AppSessionService,
    private _userService: UserServiceProxy ,
    injector: Injector,
  ) {
    super(injector);
   }

  ngOnInit(): void {
    this.editCheck=false;

    this.userId =this._sessionService
      .userId;

      this._userService
        .get(this.userId)
        .subscribe((result: UserDto)=>{
          this.user = result;
          console.log(this.user);
          this.fullName = this.user.name+' '+this.user.surname;
        })
  }

  edit(){
    if(this.editCheck == false){
      this.editCheck = true;
    }else{
      this.editCheck= false;
    }
  }

  save(user){
    this._userService.update(user)
      .subscribe(result=>{
        console.log('update',result);
        this.notify.info('Saved Successfully');
        this.editCheck = false;
        this.ngOnInit();
      })
  }

}
