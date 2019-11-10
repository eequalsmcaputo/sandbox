import { Directive,
  HostBinding,
  HostListener,
  ElementRef} from '@angular/core';

@Directive({
  selector: '[appDropdown]'
})
export class DropdownDirective {
  @HostBinding('class.open')
  open: boolean = false;

  // Listen for click event on the document
  // as a whole so clicking anywhere will
  // close the dropdown
  @HostListener('document:click',
    ['$event']) toggleOpen(event: Event) {
    this.open = this.elRef
      .nativeElement
      .contains(event.target) ?
        !this.open : false;
  }
  constructor(private elRef: ElementRef) {}
}
