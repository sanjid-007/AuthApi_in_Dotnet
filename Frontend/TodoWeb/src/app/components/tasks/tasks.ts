import { Component, OnInit } from '@angular/core';
import { Task } from '../../services/task';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Auth } from '../../services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tasks',
  standalone: false,
  templateUrl: './tasks.html',
  styleUrl: './tasks.scss',
})
export class Tasks implements OnInit {
  tasks: any[] = [];
  taskForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private taskService: Task,
    private authService: Auth,
    private router: Router
  ) {
    this.taskForm = this.fb.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      status: [1, [Validators.required]],
      priority: ['Low', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.taskService.getTasks().subscribe({
      next: (data: any[]) => {
        this.tasks = [...data];
      },
      error: (error: any) => {
        console.error('Error fetching tasks:', error);
      }
    });
  }
  onSubmit(): void {
    if (this.taskForm.valid) {
      const formData = this.taskForm.value;
      this.taskService.addTask(formData).subscribe({
        next: (response : any) => {
          console.log('Task added successfully:', response);
          this.tasks.push(response);
          this.taskForm.reset();
        },
        error: (error : any) => {
          console.error('Error adding task:', error);
        }
      });
      console.log('Task Submitted:', formData);
    }
  }

  
}
