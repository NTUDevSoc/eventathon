import { client } from "./http-helpers";

export const registerAttendance = (userId, eventId) => {
  return client.post('attendance', { userId, eventId }).then(response => response.data);
}