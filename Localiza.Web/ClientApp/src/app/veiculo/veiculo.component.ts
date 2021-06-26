import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Veiculo } from '../modelo/veiculo';
import { VeiculoServico } from '../servicos/veiculo/veiculo.servico';

@Component({

  selector: "veiculo",
  templateUrl: "./veiculo.component.html",
  styleUrls: ["./veiculo.component.css"]


})

/*todo component deve ser adicionado ao módulo principal providers[]*/

export class VeiculoComponent implements OnInit {

  public veiculo: Veiculo;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem: string;

  constructor(private veiculoServico: VeiculoServico, private router: Router) {

  }
  ngOnInit(): void {
    var veiculoSession = sessionStorage.getItem('veiculoSession');

    if (veiculoSession) {

      this.veiculo = JSON.parse(veiculoSession); // aqui chama o carro escolhido para editar e  completar os campos

    } else {

      this.veiculo = new Veiculo(); // Aqui instancia objeto Veiculo para cadastrar nosvos carros
    }

  }

  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativarEspera();
    this.veiculoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          this.veiculo.nomeArquivo = nomeArquivo;
          console.log(nomeArquivo);

          this.desativarEspera();
        },
        e => {
          console.log(e.error);
          this.desativarEspera();
        });
  }

  public cadastrar() {
    this.ativarEspera();
    this.veiculoServico.cadastrar(this.veiculo)
      .subscribe(
        veiculoJson => {
          console.log(veiculoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisar-veiculo']);
        },
        e => {
          console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }
      );
  }

  public ativarEspera() {
    this.ativar_spinner = true;
  }

  public desativarEspera() {
    this.ativar_spinner = false;
  }

}
