import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../_models/user'; 
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  // currentUser$: Observable<User>;

  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    // this.currentUser$ = this.accounntService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/members');
      // this.loggedIn = true;
    })
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
    // this.loggedIn = false;
  }

  // getCurrentUser() {
  //   this.accounntService.currentUser$.subscribe(user => {           // $ = observable
  //     this.loggedIn = !!user;     // !! --> turns an object into boolean
  //   }, error => {
  //     console.log(error);
  //   })
  // }

}
