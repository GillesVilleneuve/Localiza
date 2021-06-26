import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { VeiculoComponent } from './veiculo/veiculo.component';
import { VeiculoServico } from './servicos/veiculo/veiculo.servico';
import { PesquisaVeiculoComponent } from './veiculo/pesquisa/pesquisa.veiculo.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VeiculoComponent,
    PesquisaVeiculoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'veiculo', component: VeiculoComponent },
      { path: 'pesquisar-veiculo', component: PesquisaVeiculoComponent }

    ])
  ],
  providers: [VeiculoServico],
  bootstrap: [AppComponent]
})
export class AppModule { }

