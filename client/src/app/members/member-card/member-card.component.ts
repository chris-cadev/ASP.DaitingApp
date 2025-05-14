import { Component, input } from '@angular/core';
import { Member } from '../member';

@Component({
  selector: 'app-member-card',
  imports: [],
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.scss',
})
export class MemberCardComponent {
  member = input.required<Member>();
}
