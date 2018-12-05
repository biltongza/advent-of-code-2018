namespace Day3.Part1
open System


module Library =

    type Point = {X: int; Y: int}
    type Rectangle = {TopLeft: Point; TopRight: Point; BottomLeft: Point; BottomRight: Point}
    type Claim = {ID:int; OffsetX:int; OffsetY:int; Width:int; Height:int}

    let parseClaim (x:string) =
        let idEndIndex = x.IndexOf("@")
        let id = Int32.Parse(x.[1..idEndIndex-1])

        let offsetXIndex = x.IndexOf(",")
        let offsetX = Int32.Parse(x.[idEndIndex+2..offsetXIndex-1])

        let offsetYIndex = x.IndexOf(":")
        let offsetY = Int32.Parse(x.[offsetXIndex+1..offsetYIndex-1])

        let widthIndex = x.IndexOf("x")
        let width = Int32.Parse(x.[offsetYIndex+2..widthIndex-1])

        let height = Int32.Parse(x.[widthIndex+1..x.Length-1])

        {ID=id; OffsetX=offsetX; OffsetY=offsetY; Width=width; Height=height}

    let getIntersectingArea claims =
        let getBoundingBox claims =
            let minX = (claims |> Seq.minBy(fun c -> c.OffsetX)).OffsetX
            let minY = (claims |> Seq.minBy(fun c -> c.OffsetY)).OffsetY
            let maxXClaim = (claims |> Seq.maxBy(fun c -> c.OffsetX + c.Width))
            let maxX = maxXClaim.OffsetX + maxXClaim.Width
            let maxYClaim = (claims |> Seq.maxBy(fun c -> c.OffsetY + c.Height))
            let maxY = maxYClaim.OffsetY + maxYClaim.Height

            {TopLeft = {X=minX; Y=maxY}; TopRight = {X = maxX; Y = maxY};  BottomLeft = {X = minX; Y = minY};  BottomRight = {X = maxX; Y = minY}}

        let getCountOfClaimsOnSquare x y claims =
            claims
            |> Seq.filter(fun c -> ((c.OffsetX <= x && (c.OffsetX + c.Width)  > x) && (c.OffsetY <= y && (c.OffsetY + c.Height) > y)))
            |> Seq.length

        let flatten2DArray array2D =
            seq { for x in [0..(Array2D.length1 array2D) - 1] do
                    for y in [0..(Array2D.length2 array2D) - 1] do
                        yield array2D.[x, y] }

        let boundingBox = getBoundingBox claims

        let claimMap = Array2D.create (boundingBox.TopRight.X - boundingBox.TopLeft.X) (boundingBox.TopLeft.Y - boundingBox.BottomLeft.Y) 0

        claimMap |> Array2D.iteri(fun x y _ -> Array2D.set claimMap x y (getCountOfClaimsOnSquare x y claims))

        flatten2DArray claimMap |> Seq.filter(fun i -> i >= 2) |> Seq.length