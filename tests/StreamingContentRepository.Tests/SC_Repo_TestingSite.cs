using System.Collections.Generic;
using Xunit;

public class SC_Repo_TestingSite
{

    private StreamingContent _content;
    private StreamingContentRepository _repo;

    public SC_Repo_TestingSite()
    {
        _content=new StreamingContent("Rubber", "A tire that kills people",5.8,MaturityRating.R,GenreType.Horror);
        _repo = new StreamingContentRepository();
        _repo.AddContentToDirectory(_content);
    }

    [Fact]
    public void AddToDirectory_ShouldGetCorrectBoolean()
    {
        //? AAA setup

        //? Arrange
        StreamingContent content = new StreamingContent();
        StreamingContentRepository respository = new StreamingContentRepository();

        //? Act
        bool addResult = respository.AddContentToDirectory(content);
        bool expected = true;

        //? Assert
        Assert.Equal(expected,addResult);
    }

    [Fact]
    public void GetDirectory_ShouldReturnCorrectCollectionCount()
    {
        //? AAA setup

        //? Arrange
        StreamingContent content = new StreamingContent();
        StreamingContentRepository respository = new StreamingContentRepository();
        respository.AddContentToDirectory(content);

        //? Act
        List<StreamingContent> contents = respository.GetAllContent();
        int expectedCount = 1;

        //? Assert
        Assert.Equal(expectedCount,contents.Count);
        
    }

    [Fact]
    public void GetByTitle_ShouldReturnCorrectContent()
    {
        //? Arrange -> already done

        //? Act
        StreamingContent searchResult = _repo.GetContentByTitle("Rubber");

        //? Assert
        Assert.Equal(searchResult,_content);
    }

    [Fact]
    public void UpdateExistingContent_ShouldReturnTrue()
    {
        //? Arrange
        StreamingContent newContent = new StreamingContent("Modified Name", "Modified description",1.0,MaturityRating.PG_13,GenreType.SciFi);

        //? Act
        bool updatedResult = _repo.UpdateExistingContent("Rubber",newContent);

        //? Assert
        Assert.True(updatedResult);
    }

    [Fact]
    public void DeleteExistingContent_ShouldReturnTrue()
    {
        //? Arrange
        StreamingContent content = _repo.GetContentByTitle("Rubber");

        //? Act
        bool removeResult = _repo.DeleteExistingContent(content);

        //? Assert
        Assert.True(removeResult);
    }
}