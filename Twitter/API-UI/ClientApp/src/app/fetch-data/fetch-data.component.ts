import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public tweets: Tweet[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Tweet[]>(baseUrl + 'twitter').subscribe(result => {
      this.tweets = result;
    }, error => console.error(error));
  }
}

interface Tweet {
  id: string;
  text: string;
}
