# Whisper Application


## REST Routes ##

* `POST: /signin/`

  > `Request Body: {username:string, password:string}`

* `GET: /students/{id}`

  > `Returns {student: {id:int, first_name:string, last_name:string, courses:array}}`

* `GET: /courses/student/{student_id:int}`

  > `Returns: {course: {id:int, name:string, number:int, instructor:string}}`

* `GET: /checkins/course/{course_id:int}`

  > `Returns: {checkin:{id:int, }}`
