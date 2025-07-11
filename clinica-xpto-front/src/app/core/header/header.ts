import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './header.html'
})
export class Header {

  logout() {
  // Apague token/autenticação do localStorage (exemplo)
  localStorage.removeItem('authToken');
  window.location.href = '/'; // ou use router.navigate
}

}
