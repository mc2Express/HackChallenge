import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) {

  }

  public ngOnInit(): void {
    this.sampleFormGroup = this.formBuilder.group({
      sampleText: ["", Validators.required]
    })
  }

  public sampleFormGroup: FormGroup;


}
