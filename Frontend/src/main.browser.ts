import {AppModule} from './app/app.module';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';

require( "bootstrap/dist/css/bootstrap.css");
require("./app/styling/app.sass");

platformBrowserDynamic().bootstrapModule(AppModule)
        .catch(err => console.error(err));
  