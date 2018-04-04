import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/index';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
    let sampleUser: any = {
      username: 'a' as string,
      password: 'P@$$w0rd' as string,
      grant_type: 'password' as string
    };

    this.auth.login('a', 'P@$$w0rd').then(user => {
      console.log(user.json());
    }).catch(err => {
      console.log(err);
    })
  }

}
