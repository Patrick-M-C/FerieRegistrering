import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';

import { LOCALE_ID, ApplicationConfig, mergeApplicationConfig } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localeDa from '@angular/common/locales/da';

registerLocaleData(localeDa, 'da-DK');

const localeConfig: ApplicationConfig = {
  providers: [{ provide: LOCALE_ID, useValue: 'da-DK' }]
};

bootstrapApplication(
  AppComponent,
  mergeApplicationConfig(appConfig, localeConfig)
).catch(err => console.error(err));
