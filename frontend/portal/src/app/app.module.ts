import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { CommonModule } from '@angular/common';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgcCookieConsentConfig, NgcCookieConsentModule } from 'ngx-cookieconsent';
import { PrivacyComponent } from './privacy/privacy.component';


const cookieConfig: NgcCookieConsentConfig = {
  cookie: {
    domain: 'localhost'// it is recommended to set your domain, for cookies to work properly
  },
  palette: {
    popup: {
      background: '#000'
    },
    button: {
      background: '#f1d600'
    }
  },
  theme: 'edgeless',
  type: 'opt-out',
  layout: 'my-custom-layout',
  layouts: {
    "my-custom-layout": '{{messagelink}}{{compliance}}'
  },
  elements: {
    messagelink: `
    <span id="cookieconsent:desc" class="cc-message">{{message}} 
      <a aria-label="learn more about cookies" tabindex="0" class="cc-link" href="{{cookiePolicyHref}}" target="_blank" rel="noopener">{{cookiePolicyLink}}</a>, 
      <a aria-label="learn more about our privacy policy" tabindex="1" class="cc-link" href="{{privacyPolicyHref}}" target="_blank" rel="noopener">{{privacyPolicyLink}}</a>
    </span>
    `,
  },
  content: {
    message: 'By using our site, you acknowledge that you have read and understand our ',

    cookiePolicyLink: 'Cookie Policy',
    cookiePolicyHref: 'http://localhost:4200/privacy-policy',

    privacyPolicyLink: 'Privacy Policy',
    privacyPolicyHref: 'http://localhost:4200/privacy-policy'
  }
};

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    ProductsComponent
  ],
  bootstrap: [AppComponent],
  imports: [BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    NgcCookieConsentModule.forRoot(cookieConfig)],
  providers: [provideHttpClient(withInterceptorsFromDi())]
})
export class AppModule { }
