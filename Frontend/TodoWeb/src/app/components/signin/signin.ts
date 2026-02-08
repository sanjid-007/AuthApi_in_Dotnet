import { Component } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-signin',
  standalone: false,
  templateUrl: './signin.html',
  styleUrl: './signin.scss',
})
export class Signin {
  signinForm: FormGroup;

  constructor(private fb: FormBuilder, private auth: Auth, private router: Router) {
    this.signinForm = this.fb.group({
      userName :['', [Validators.required, Validators.minLength(3)]],
      password : ['', [Validators.required, Validators.minLength(6)]]
    })
  }

  onSubmit() {
    if (this.signinForm.valid) {
      const formData = this.signinForm.value;
      this.auth.signin(formData).subscribe({
        next: (response) => {
          this.auth.setLoggedIn(response.token);
          this.router.navigate(['/tasks']);
          
        },
        error: (error) => {
          console.error('Signin failed:', error);
        }
      });
    }
  }
}
