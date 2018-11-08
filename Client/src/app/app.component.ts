import {
  Component,
  OnInit
} from '@angular/core';
import {
  HttpTransportType, HubConnectionBuilder
} from '@aspnet/signalr'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  ngOnInit() {
    //HubConnection ha un costruttore privato. Per crearlo devo usare ConnectionBuilder
    let builder = new HubConnectionBuilder();
    builder.withUrl('http://localhost:5000/api/message', {
      skipNegotiation: true,
      transport: HttpTransportType.WebSockets
    });
    //Poi buildo connection
    var connection = builder.build();

    connection.on('send', data => {
      console.log(data);
    });

    connection.start()
      .then(() => console.log("Connected"));
  }
}