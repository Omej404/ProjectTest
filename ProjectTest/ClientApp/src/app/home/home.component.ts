import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CandidatService } from '../services/candidat.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private ca: CandidatService) {
    this.registrationForm = this.formBuilder.group({
      Nom: ['', Validators.required],
      Prenom: ['', Validators.required],
      Mail: ['', [Validators.required, Validators.email]],
      Telephone: ['', Validators.required],
      NiveauEtude: ['', Validators.required],
      Experience: ['', Validators.required],
      DernierEmpl: ['', Validators.required],
      CV: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      const formData = {
        Nom: this.registrationForm.value.Nom,
        Prenom: this.registrationForm.value.Prenom,
        Mail: this.registrationForm.value.Mail,
        Telephone: this.registrationForm.value.Telephone,
        NiveauEtude: this.registrationForm.value.NiveauEtude,
        Experience: this.registrationForm.value.Experience,
        DernierEmpl: this.registrationForm.value.DernierEmpl,
        CV: this.registrationForm.value.CV
      };

      // Send the extracted form data to your service
      this.ca.register(formData).subscribe({
        next: (ca) => {
          this.registrationForm.reset();
        }
      });

      console.log('Form data submitted:', formData);
    }
  }

  handleFileInput(event: Event) {
    const target = event.target as HTMLInputElement;
    if (target.files && target.files[0]) {
      const file = target.files[0];
      // Handle file upload and validation here
    }
  }
}
