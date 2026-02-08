import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { Auth } from '../../services/auth';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-signup',
  standalone: false,
  templateUrl: './signup.html',
  styleUrl: './signup.scss',
})
export class SignupComponent {
  signupForm: FormGroup;

  constructor(private fb : FormBuilder, private auth: Auth, private router: Router) {
    this.signupForm = this.fb.group({
      username : ['',[Validators.required, Validators.minLength(3)]],
      firstName : ['',[Validators.required, Validators.minLength(3)]],
      lastName : ['',[Validators.required, Validators.minLength(3)]],
      email : ['',[Validators.required, Validators.email]],
      password : ['',[Validators.required, Validators.minLength(6)]]
    })
  }
  onSubmit(): void {
    if (this.signupForm.valid) {
      const formData = this.signupForm.value;
      this.auth.signup(formData).subscribe({
        next: (response) => {
          console.log('Signup successful:', response);
          this.router.navigate(['/signin']);
        },
        error: (error) => {
          console.error('Signup failed:', error);
        }
      });
    } else {
      console.log('Form is invalid');
    }
  }


}
