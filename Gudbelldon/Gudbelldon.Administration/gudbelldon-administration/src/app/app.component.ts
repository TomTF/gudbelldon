import { Component } from '@angular/core';

import { DataManagerService } from 'app/service';

@Component({
  selector: 'gbd-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [DataManagerService]
})
export class AppComponent {
  title = 'app works!';
}
