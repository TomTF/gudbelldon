import { EventDto } from 'app/dto';
import { Component, OnInit } from '@angular/core';
import { DataManagerService } from 'app/service';

@Component({
  selector: 'gbd-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {

  public events: EventDto[];

  constructor(private datamanager: DataManagerService) { }

  ngOnInit() {
    this.datamanager.loadEvents().subscribe(events => {
      this.events = events;
    });
  }
}
