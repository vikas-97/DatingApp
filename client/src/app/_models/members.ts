import { Photo } from "./photo";

export interface Member {
    id: number
    username: string;
    photoUrl: string;
    age: number;
    knownAs: string;
    created: Date;
    active: Date;
    gender: string;
    introduction: string;
    lookingFor: string;
    interest: any;
    city: string;
    country: string;
    photos: Photo[];
  }
  
