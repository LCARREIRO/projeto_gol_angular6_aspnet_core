import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AirplaneService } from 'src/app/services/airplane.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-airplane-editar',
  templateUrl: './airplane-editar.component.html'
})
export class AirplaneEditarComponent implements OnInit {

  formulario: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private airplaneService: AirplaneService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit() {

    let id = this.activateRoute.snapshot.params.id;

    this.airplaneService.obterPorId(id).subscribe(
      res => {
        this.formulario = this.formBuilder.group({
          id: res.id,
          codigo: res.codigo,
          modelo: res.modelo,
          quantidadePassageiros: res.quantidadePassageiros
        });
      },
      error => {
        console.log(error);
      });
  }

  salvar() {

    this.airplaneService.atualizar(this.formulario.value).subscribe (
      res => {
        this.router.navigate(['']);
      },
      error => {
        console.log(error);
      }
    );
  }
}

