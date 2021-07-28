class ApiHelper {
    async _callApi(url, settings) {
        const responseApi = await fetch(url, settings);
        const responseData = await responseApi.json();

        console.log('after json');
        console.log(responseData);

        if (responseData.notificationType) {
            console.log('in if');
            NotificationHelper.addNotification(responseData.notificationType, responseData.notificationText);
            return responseData.data;
        }

        console.log('before last return');
        console.log(responseData);
        return responseData;
    }

    // --- Groups
    async fetchCreateGroup(groupName) {
        await this._callApi(`api/Group/CreateGroup?groupName=${groupName}`, { method: 'POST' })
    }

    async fetchGetGroups(course, year) {
        return await this._callApi(`api/Group/GetGroups?course=${course}${year ? `&year=${year}` : ''}`);
    }

    // --- Students
    async fetchGetStudents(groupId, year) {
        return await this._callApi(`api/StudentCard/GetStudents?groupId=${groupId}&year=${year}`);
    }

    // --- Reports
    async fetchCreateReport(studentId) {
        await this._callApi(`api/Report/CreateReport?studentId=${studentId}`);
    }

    // --- YearPlan
    async fetchCreateYearPlan(data) {
        await this._callApi(`api/YearPlan/AddYearPlan`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }

    async fetchUpdateYearPlan(yearPlanId, data) {
        await this._callApi(`api/YearPlan/UpdateYearPlan?yearPlanId=${yearPlanId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }

    async fetchGetYearPlan(groupId, year) {
        return await this._callApi(`api/YearPlan/GetYearPlanByGroup?groupId=${groupId}&year=${year}`);
    }

};



