import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})

export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup;
  isEditMode: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.employeeForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      position: ['', Validators.required],
      department: ['', Validators.required]
    });
   }

   ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.loadEmployee(id);
    }
   }

   loadEmployee(id: string): void {
    this.employeeService.getEmployeeById(id).subscribe(employee => this.employeeForm.patchValue(employee),
      (error) => console.error('Error loading employee:', error)
    );
   }

   onSubmit(): void {
    if (this.employeeForm.valid) {
      const employee: Employee = this.employeeForm.value;
      if (this.isEditMode) {
        employee.id = this.route.snapshot.paramMap.get('id')!;
        this.employeeService.updateEmployee(employee).subscribe(
          () => this.router.navigate(['/employees']),
          (error) => console.error('Error updating employee:', error)
        );
      } else {
        this.employeeService.createEmployee(employee).subscribe(
          () => this.router.navigate(['/employees']),
          (error) => console.error('Error creating employee:', error)
        );
      }
    }
   }
}
