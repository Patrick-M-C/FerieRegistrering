export interface User {
  id: number;
  name: string;
  lastName : string;
  email : string;
  dateOfBirth : Date;
}

export function resetUser(): User {
  return {
    id: 0,
    name: '',
    lastName : '',
    email : '',
    dateOfBirth : new Date()
  };
}