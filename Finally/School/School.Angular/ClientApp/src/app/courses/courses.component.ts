import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent {
  public courses: Course[];
  public coursesAll: Course[];
  isFilterApplied: boolean=false;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>(baseUrl + 'courses').subscribe(result => {
      this.coursesAll = result;
      this.courses =result;
    }, error => console.error(error));
  }

  filter(topicId: number): void
  {
    this.courses = this.coursesAll.filter(c=>c.topicId === topicId);
    this.isFilterApplied=true;
  }

  clearFilter()
  {
    this.isFilterApplied=false;
    this.courses = this.coursesAll;
  }
}

interface Course {
  title: string;
  topicId: number;
  topicName: string;
}
