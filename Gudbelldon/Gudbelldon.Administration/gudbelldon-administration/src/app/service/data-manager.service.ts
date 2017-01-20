import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { EventDto } from 'app/dto';

@Injectable()
export class DataManagerService {

  private baseUrl: string;

  constructor(private httpService: Http) {
    this.baseUrl = 'http://localhost:52506/';
  }

  public loadEvents(): Observable<EventDto[]> {
    return this.httpService.get(this.baseUrl + 'api/events').map(e => e.json());
  }

  public saveOrUpdateEvent(event: EventDto): Observable<EventDto> {
    return this.httpService.post(this.baseUrl + 'api/events', event).map(e => e.json());
  }
}
