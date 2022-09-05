import { Component } from '@angular/core';
import { Tweet } from '../tweet.model';
import { TwitterService } from '../twitter.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public tweets: Tweet[] = [];

  constructor(private service: TwitterService) {
    this.getTweets();
  }

  getTweets(size: number = 10) {
    this.service.getDotNetAzureTweets(size).subscribe(result => {
      this.tweets = result;
    },
      error => console.error(error));;
  }
}
