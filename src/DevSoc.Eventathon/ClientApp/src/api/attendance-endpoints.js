import { client } from "./http-helpers";

export const registerAttendance = (userId, eventId) => {
  return client.post('api/attendance', { userId, eventId }).then(response => response.data);
}