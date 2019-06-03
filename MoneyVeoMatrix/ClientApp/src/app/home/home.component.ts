import { Component, Inject, Testability } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpMatrixService } from './service/http-matrix.service';
import { ReplaySubject, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public matrixDTO: Matrix[];
  private onDestroy$: Subject<any> = new Subject<any>();

  constructor(private http: HttpMatrixService) { }

  ngOnInit() {
    this.http.getMatrixResult().subscribe(res => {
      this.matrixDTO = res;
    });
  }

  public RotateMatrix() {
    this.http.postRotateMatrixResult(this.matrixDTO).subscribe(res => {
      this.matrixDTO = res;
    });
  }

  public ExportMatrix() {
    this.http.postExportMatrix(this.matrixDTO).subscribe();
    alert("Export is successful");
  }

  public GenerateMatrix() {
    this.http.getGenerateMatrixResult().subscribe(res => {
      this.matrixDTO = res;
    });
  }
}


