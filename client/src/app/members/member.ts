import { Photo } from "./photo";

export interface Member {
    id: number;
    username: string;
    firstName: string;
    lastName: null;
    age: number;
    photoUrl: string;
    knownAs: string;
    gender: string;
    introduction: string;
    lookingFor: string;
    interests: string;
    city: string;
    country: string;
    created: Date;
    lastActive: Date;
    photos: Photo[];
}

