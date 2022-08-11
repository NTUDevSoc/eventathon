import { FunctionComponent } from 'react'
import { useHistory } from "react-router-dom";
import { registerAttendance } from '../api/attendance-endpoints';

export const ConfirmAttendance: FunctionComponent = () => {
    const history: any = useHistory();

    const givenId: string = history.location.state.givenId
    const givenTitle: string = history.location.state.givenTitle
    const givenDescription: string = history.location.state.givenDescription
    const givenStart: string = history.location.state.givenStart
    const givenEnd: string = history.location.state.givenEnd

    const SendAttendance = async () => {
        const mockUserId: string = '107';
        await registerAttendance(mockUserId, givenId);
        history.push('/');
    }

    return (
        <div className="my-3">
            <h1><u>Event!</u></h1>
            <ul>
                <li> Event ID: {givenId}</li>
                <li> Title: {givenTitle}</li>
                <li> Description: {givenDescription}</li>
                <li> Start: {givenStart}</li>
                <li> End: {givenEnd}</li>
            </ul>
            <button className="btn btn-primary" onClick={SendAttendance}>Register Attendance</button>

        </div>
    );
}