import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AirplaneService } from 'src/app/services/airplane.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-airplane-cadastrar',  
  templateUrl: './airplane-cadastrar.component.html',
  styleUrls: ['./airplane-cadastrar.component.css']
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

    if (this.formulario.valid == false) {
      alert('Preencha todos os campos do fomrulário');
      return;
    }

    if (this.formulario.valid)

      this.airplaneService.salvar(this.formulario.value).subscribe(
        res => {
          //this.router.navigate(['']),
          if (res.success == true)
             alert(res.message);
        },
        error => {
          var obj = JSON.parse(error._body);
          alert(obj.message);
        }
      );
  }

  formReset() {
    this.formulario.reset();
  }
}

