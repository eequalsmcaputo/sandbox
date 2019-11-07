import {
  Component,
  OnInit,
  Input,
  ViewEncapsulation,
  OnChanges,
  SimpleChanges,
  AfterContentInit,
  AfterContentChecked,
  AfterViewInit,
  AfterViewChecked,
  OnDestroy,
  ViewChild,
  ElementRef,
  ContentChild} from '@angular/core';

@Component({
  selector: 'app-server-element',
  templateUrl: './server-element.component.html',
  styleUrls: ['./server-element.component.css'],

  // Control whether styles are global or local
  encapsulation: ViewEncapsulation.Emulated
})
export class ServerElementComponent
implements
  OnInit,
  OnChanges,
  AfterContentInit,
  AfterContentChecked,
  AfterViewInit,
  AfterViewChecked,
  OnDestroy {

  // tslint:disable-next-line: no-input-rename
  @Input('srvElement')
  element: {type: string, name: string,
    content: string};

  @Input()
  name: string;

  @ViewChild('heading', { static: true})
  header: ElementRef;

  @ContentChild('contentParagraph',
    { static: true })
  paragraph: ElementRef;

  constructor() {
    console.log('Constructor called');
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('ngOnChanges called', changes);
  }

  ngOnInit() {
    console.log('ngOnInit called');
    console.log(this.header
      .nativeElement.textContent);
    console.log('Text content of paragraph: ',
    this.paragraph
      .nativeElement.textContent);
  }

  ngAfterContentInit() {
    console.log('ngAfterContentInit called');
    console.log('Text content of paragraph: ',
    this.paragraph
      .nativeElement.textContent);
  }

  ngAfterContentChecked() {
    console.log('ngAfterContentChecked called');
  }

  ngAfterViewInit() {
    console.log('ngAfterViewInit called');
    console.log(this.header
      .nativeElement.textContent);
  }

  ngAfterViewChecked() {
    console.log('ngAfterViewChecked called');
  }

  ngOnDestroy() {
    console.log('ngOnDestroy called');
  }
}
