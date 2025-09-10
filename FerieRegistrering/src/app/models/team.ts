import  { TeamMember } from './Teammember';

export interface Team {
  teamId: number;
  name: string;
  description: string;
  isActive: boolean;
  leaderUserId: number;
  createdAtUtc: Date;
  members: TeamMember[];
}
