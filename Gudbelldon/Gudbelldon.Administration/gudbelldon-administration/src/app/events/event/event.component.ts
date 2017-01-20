import { Component, OnInit, Input } from '@angular/core';
import { Subject } from 'rxjs';

import { EventDto } from 'app/dto';
import { DataManagerService } from 'app/service';

@Component({
  selector: 'gbd-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.scss']
})
export class EventComponent implements OnInit {
  @Input() event: EventDto;

  private saveSubject: Subject<EventDto>;

  constructor(private dataManager: DataManagerService) {
    this.saveSubject = new Subject<EventDto>();
    this.saveSubject.debounceTime(2000)
      .subscribe(() => {
        this.dataManager.saveOrUpdateEvent(this.event)
          .subscribe((event) => this.event = event);
      });
  }

  ngOnInit() {
  }

  public eventChanged() {
    this.saveSubject.next(this.event);
  }
}
