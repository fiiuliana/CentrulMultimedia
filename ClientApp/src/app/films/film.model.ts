import { Time } from "@angular/common";

export class Film {
  id: number;
  title: string;
  description: string;
  genre: string;
  lengthInMinutes: number;
  yearOfRelease: number;
  director: string;
  dateTime: string;
  rating: number;
  watched: boolean;
}
