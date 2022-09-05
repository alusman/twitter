import { Injectable } from "@angular/core";
import { Inject } from '@angular/core';
import { Tweet } from "./tweet.model";
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable()
export class TwitterService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  getDotNetAzureTweets(size: number) {
    const params = new HttpParams()
      .set('query', '%23dotnetcore, %23azure') // %23 escapes # for the uri
      .set('size', size);

    return this.http.get<Tweet[]>(this.baseUrl + 'twitter', { params });
  }
}
