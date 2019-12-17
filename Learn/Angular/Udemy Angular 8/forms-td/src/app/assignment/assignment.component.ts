import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.css']
})
export class AssignmentComponent implements OnInit {
  @ViewChild('f', { read: false, static: false }) frm: NgForm;
  defaultSubscription: string = 'advanced';
  emailAddr: string = '';
  pwd: string = '';
  subscription: string = '';

  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
    console.log(this.frm);

    this.emailAddr = this.frm.value.email;
    this.pwd = this.frm.value.password;
    this.subscription = this.frm.value.subscription;
  }
}
