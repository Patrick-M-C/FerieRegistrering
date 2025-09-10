export interface User {
  id: number;
  name: string;
  lastName: string;
  email: string;
  dateOfBirth: Date | string;
  role: number;        
  isActive: boolean;
  teamId?: number | null;
  password: string; 
}

export function resetUser(): User {
  return {
    id: 0,
    name: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date(),
    role: 0,          
    isActive: true,   
    teamId: null,
    password: ''
  };
}
