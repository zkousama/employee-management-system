import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})

export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employeeService.getEmployees().subscribe(
      (employees) => this.employees = employees,
      (error) => console.error('Error loading employees:', error)
    );
  }

  deleteEmployee(id: string): void {
    this.employeeService.deleteEmployee(id).subscribe(
      () => this.loadEmployees(),
      (error) => console.error('Error deleting employee:', error)
    );
  }
}