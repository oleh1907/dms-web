import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'dmv-web';
  serverResponse: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get(environment.api + 'weatherforecast').subscribe(value => {
      this.serverResponse = value;
    });
  }
}
