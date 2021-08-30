class ApiHelper {
    async _callApi(url, settings) {
        const responseApi = await fetch(url, settings);

        // todo: проверить на карточке студента (добавление) как ведет себя логика
        // if (!responseApi.ok) {
        //     NotificationHelper.addNotification("error", "Что то пошло не так, скорее всего не все поля были заполнены!");
        //     return;
        // }

        const responseData = await responseApi.json();

        if (responseData.exceptionJSON !== "ok") {
            console.log(responseData.exceptionJSON);
        }

        if (responseData.notificationType) {
            NotificationHelper.addNotification(responseData.notificationType, responseData.notificationText);
            return;
        }

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
        return await this._callApi(`api/StudentCard/GetStudents?groupId=${groupId}${year ? `&year=${year}` : ''}`);
    }

    async fetchGetStudent(id) {
        return await this._callApi(`api/StudentCard/ShowStudentInfo?studentId=${id}`);
    }

    // --- Reports
    async fetchCreateReport(studentId) {
        await this._callApi(`api/Report/CreateReport?studentId=${studentId}`);
    }

    // --- YearPlans
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

    // --- Progress
    async fetchGetProgress(year, groupId, semesterId) {
        return await this._callApi(`api/Progress/GetProgress?year=${year}&groupId=${groupId}&semesterId=${semesterId}`);
    }

    async fetchUpdateProgress(data) {
        await this._callApi(`api/Progress/UpdateProgress`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }

    // --- Specialities
    async fetchGetSpecialities(degreeId) {
        return await this._callApi(`api/StudentCard/GetSpecialities?degreeId=${degreeId}`);
    }

    // --- StudentCard
    async fetchStudentCardSave(data) {
        await this._callApi(`api/StudentCard/SaveStudentCardInfo`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }

    async fetchStudentCardUpdate(id, data) {
        await this._callApi(`api/StudentCard/UpdateStudentCardInfo?studentId=${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }

    // --- TransferStudents

    // todo: The same as fetchGetStudents? Have to check
    async fetchGetStudentsForTransfer(groupId, year) {
        return await this._callApi(`api/Transfer/GetStudentsForTransfer?groupId=${groupId}&year=${year}`);
    }

    async fetchUpdateTransferStudents(data) {
        await this._callApi(`api/Transfer/TransferStudents`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
    }
};
