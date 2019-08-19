import { Component } from '@angular/core';
import { Airplane } from 'src/app/models/airplane-model';
import { AirplaneService } from 'src/app/services/airplane.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-airplane-listar',
  templateUrl: './airplane-listar.component.html'
})
export class AirplaneListarComponent {

  public airplanes: Airplane[] = [];

  constructor(private airplaneService: AirplaneService, private router: Router) { }

  ngOnInit() {
    this.airplaneService.obterTodos().subscribe(
      res => {
        this.airplanes = res;
      },
      error => {
        alert(error);
      }
    );
  }

  editar(id: string) {
    this.router.navigate(['/editar/' + id])
  };

  delete(id: string) {
    let result = confirm("Confirma exclusão?");

    if (result) {
      this.airplaneService.delete(id).subscribe(

        res => {
          this.loadData();
        },
        error => {
          alert(error);
        }
      );
    }
  }

  loadData() {
    this.airplaneService.obterTodos().subscribe(
      res => {
        this.airplanes = res;
      },
      error => {
        alert(error);
      }
    );
  }
}

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<Airplane[]>(baseUrl + 'v1/airplane').subscribe(result => {
  //    this.airplanes = result;
  //  }, error => console.error(error));
  //}

