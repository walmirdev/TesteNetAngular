import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  myForm: FormGroup;
  bruto: number;
  liquido: number;

  constructor(private formBuilder: FormBuilder) {
    this.myForm = this.formBuilder.group({
      valor: [0, Validators.required],
      prazo: [1, Validators.required]
    })
    this.bruto = 0;
    this.liquido = 0;
  }

  onSubmit() {
    const valor = this.myForm.value.valor
    const prazo = this.myForm.value.prazo
    fetch(`https://localhost:44354/api/cdb?valor=${valor}&prazo=${prazo}`)
      .then((response) => response.json())
      .then((data) => {
        this.bruto = data.bruto
        this.liquido = data.liquido
      })
  }
}
