import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.scss'
})
export class LogoutComponent implements OnInit {
  router: Router

  constructor(router: Router){
    this.router = router
  }

  ngOnInit(): void {
    
    localStorage.setItem('token', '')
    localStorage.setItem('token-expiration', '')
    localStorage.setItem('username', '')
    localStorage.clear()
    console.log("Logout complete");
    this.router.navigate(['/home'])
  }
}
