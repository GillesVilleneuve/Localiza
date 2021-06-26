import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Veiculo } from "../../modelo/veiculo";



@Injectable({

  providedIn: "root"

})

export class VeiculoServico implements OnInit {


  private _baseUrl: string;
  public veiculos: Veiculo[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl; // pega o endereço raiz do site
  }

  ngOnInit(): void {
    this.veiculos = [];
  }




  get headers(): HttpHeaders {

    return new HttpHeaders().set('content-type', 'application / json');;
  }

  public cadastrar(veiculo: Veiculo): Observable<Veiculo> {

    return this.http.post<Veiculo>(this._baseUrl + "api/veiculo", JSON.stringify(veiculo), { headers: this.headers });

  }

  public salvar(veiculo: Veiculo): Observable<Veiculo> {


    return this.http.post<Veiculo>(this._baseUrl + "api/veiculo/salvar", JSON.stringify(veiculo), { headers: this.headers });

  }

  public deletar(veiculo: Veiculo): Observable<Veiculo[]> {

    return this.http.post<Veiculo[]>(this._baseUrl + "api/veiculo/deletar", JSON.stringify(veiculo), { headers: this.headers });

  }

  public obterTodosVeiculos(): Observable<Veiculo[]> {

    return this.http.get<Veiculo[]>(this._baseUrl + "api/veiculo");

  }

  public obterVeiculo(veiculoId: number): Observable<Veiculo> {

    return this.http.get<Veiculo>(this._baseUrl + "api/veiculo");

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    const formData: FormData = new FormData();
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this._baseUrl + "api/veiculo/enviarArquivo", formData);

  }

}
