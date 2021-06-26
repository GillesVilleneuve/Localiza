import { Component } from "@angular/core";
import { OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Veiculo } from "../../modelo/veiculo";
import { VeiculoServico } from "../../servicos/veiculo/veiculo.servico";

@Component({
  selector: "pesquisa-veiculo",
  templateUrl: "./pesquisa.veiculo.component.html",
  styleUrls: ["./pesquisa.veiculo.component.css"]

})


export class PesquisaVeiculoComponent implements OnInit {

  public veiculos: Veiculo[];


  constructor(private veiculoServico: VeiculoServico, private router: Router) {
    this.veiculoServico.obterTodosVeiculos()
      .subscribe(
        veiculos => {

          this.veiculos = veiculos;

        },
        e => {

          console.log(e.error);
        }


      );

  }

  ngOnInit(): void {

  }

  public adicionarVeiculo() {

    sessionStorage.setItem('veiculoSession', '');
    this.router.navigate(['/veiculo']);

  }
  public deletarVeiculo(veiculo: Veiculo) {
    var retorno = confirm("Deseja realmente deletar o veículo selecionado ?");
    if (retorno == true) {
      this.veiculoServico.deletar(veiculo)
        .subscribe(
          veiculos => {
            this.veiculos = veiculos;
          },
          e => {

            console.log(e.errors);
          }



        );
    }
  }


  public editarVeiculo(veiculo: Veiculo) {

    sessionStorage.setItem('veiculoSession', JSON.stringify(veiculo));
    this.router.navigate(['/veiculo']);
  }

}
