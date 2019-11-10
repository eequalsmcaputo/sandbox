import { Directive, Renderer2, OnInit,
  ElementRef,
  HostListener,
  HostBinding,
  Input} from '@angular/core';

@Directive({
  selector: '[appBetterHighlight]'
})
export class BetterHighlightDirective
  implements OnInit {
  @Input() defaultColor: string = 'transparent';

  // Set alias to same as directive selector
  // to allow for assignment of property values
  // to the directive itself
  @Input('appBetterHighlight') highlightColor: string = 'blue';

  @HostBinding('style.backgroundColor')
  backgroundColor: string = this.defaultColor;

  constructor(private elementRef: ElementRef,
    private renderer: Renderer2) { }

  ngOnInit() {
    this.backgroundColor = this.defaultColor;
  }

  @HostListener('mouseenter') mouseover(
    eventData: Event) {
      /* this.renderer.setStyle(this.elementRef
        .nativeElement, 'backgroundColor', 'blue'); */
      this.backgroundColor = this.highlightColor;
  }

  @HostListener('mouseleave') mouseleave(
    evenData: Event) {
      /* this.renderer.setStyle(this.elementRef
        .nativeElement, 'backgroundColor',
        'transparent'); */
      this.backgroundColor = this.defaultColor;
  }
}
