CREATE VIEW StudentGrades
AS

SELECT RosterId, a.ClassId, sum(g.points) as ptsRecieved, sum(a.possiblePoints) as ptsTotal,
(100.*sum(g.points)/sum(a.possiblePoints)) as [percent],

CASE
WHEN (100.*sum(g.points)/sum(a.possiblePoints))<60 THEN 'F'
WHEN (100.*sum(g.points)/sum(a.possiblePoints))<70 THEN 'D'
WHEN (100.*sum(g.points)/sum(a.possiblePoints))<80 THEN 'C'
WHEN (100.*sum(g.points)/sum(a.possiblePoints))<90 THEN 'B'
WHEN (100.*sum(g.points)/sum(a.possiblePoints))<100 THEN 'A'
END AS LetterGrade

FROM grade g
        INNER JOIN Assignment a
        ON a.AssignmentId=g.AssignmentId

GROUP BY ClassID, RosterId

GO