import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AirplaneService } from 'src/app/services/airplane.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-airplane-cadastrar',
  templateUrl: './airplane-cadastrar.component.html'
})
export class AirplaneCadastrarComponent implements OnInit {

  formulario: FormGroup

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private airplaneService: AirplaneService
  ) { }

  ngOnInit() {
    this.formulario = this.formBuilder.group({
      codigo: [null, Validators.required],
      modelo: [null, Validators.required],
      quantidadePassageiros: [0, Validators.required],
    })
  }

  salvar() {

    this.airplaneService.salvar(this.formulario.value).subscribe(
      res => {
        this.router.navigate([''])
      },
      error => {
        console.log(error);
      }
    );
  }

  formReset() {
    this.formulario.reset();
  }
}

